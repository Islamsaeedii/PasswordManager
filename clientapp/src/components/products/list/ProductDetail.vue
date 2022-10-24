<script>
import { mapGetters, mapActions } from "vuex";

export default {
  name: "ProductDetail",
  props: {
    product: {
      type: Object,
      required: true,
    },
    index: {
      type: Number,
      required: true,
      default: 0,
    },
  },

  computed: { ...mapGetters(["isDeleting", "deletedData"]) },

  methods: {
    ...mapActions(["deleteProduct", "fetchAllProducts"]),

    deleteProductModal(id) {
      this.$swal
        .fire({
          text: "Are you sure to delete the Info ?",
          icon: "error",
          cancelButtonText: "Cancel",
          confirmButtonText: "Yes, Confirm Delete",
          showCancelButton: true,
        })
        .then((result) => {
          if (result["isConfirmed"]) {
            // Put delete logic
            this.deleteProduct(id);
            this.fetchAllProducts({
              page: 1,
              search: ''
            });
            this.$swal.fire({
              text: "Success, Info has been deleted.",
              icon: "success",
              position: 'top',
              timer: 1000,
            });
            window.location.reload();
          }
        });
    }
  },
};
</script>
<template>

  <div class="d-flex justify-content-between border-top p-2 ">
    <div class="product-info-left">
      <div class="product-url">
        {{ product.url }}
      </div>
      <div class="">
        <strong class="text-secondary">{{ product.email }}</strong>
      </div>
    </div>
    <div class="product-info-right">
      <router-link
        :to="{ name: 'ProductEdit', params: { id: product.id } }"
        class="btn btn-primary mr-2"
        title="Edit Product"
      >
        <i class="fa fa-pencil" />
      </router-link>
      <button class="btn btn-danger mx-2" title="Delete Product" @click="deleteProductModal(product.id)">
        <i class="fa fa-trash" />
      </button>
    </div>
  </div>
</template>



<style scoped>
.product-url {
  color: black;
  font-weight: bold;
}
</style>
