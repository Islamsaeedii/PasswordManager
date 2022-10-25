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
data(){
  return{
    togglePassword:'password'
  }
},
  computed: { ...mapGetters(["isDeleting", "deletedData"]) },

  methods: {
    ...mapActions(["deleteProduct", "fetchAllProducts"]),
    showPassword() {
      if(this.togglePassword=='password'){
        this.togglePassword='text'
      }
      else if(this.togglePassword=='text'){
        this.togglePassword='password'
      }
    },

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

  <div class="d-flex justify-content-between border-top p-2 line">
    <div class="product-info-left">
      <div class="product-url">
        {{ product.url }}
      </div>
      <div class="">
        <strong class="text-secondary">{{ product.email }}</strong>
      </div>

      <div class="">

        <input class="textPass" id="password" :type="togglePassword" 
          disabled
         v-model="product.password"  />
        <!-- show passord and hide -->
        <i class="fa fa-eye" aria-hidden="true" @click="showPassword()"></i>

      </div>

      <div class="">
        <strong class="text-secondary">{{ product.description }}</strong>
      </div>

    </div>
    <div class="product-info-right">
      <router-link :to="{ name: 'ProductEdit', params: { id: product.id } }" class="btn btn-primary mr-2"
        title="Edit Product">
        <i class="fa fa-pencil" />

      </router-link>
      <button class="btn btn-danger mx-2" title="Delete Product" @click="deleteProductModal(product.id)">
        <i class="fa fa-trash" />
      </button>
    </div>
  </div>
</template>



<style scoped>
.line {
  border-bottom: 2px solid #e0e0e0;
  padding-top: 20px !important;
  padding-bottom: 20px !important;
}


.product-url,
.text-secondary {
  color: black !important;
  font-weight: bold !important;
}



.textPass {
  border: none;
  background-color: transparent;
  color: black;
  font-weight: bold;
}
</style>