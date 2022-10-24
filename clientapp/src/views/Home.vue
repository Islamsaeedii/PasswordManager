<template>
  <div class="home mt-5">
    <div>
      <product-list-component />
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from "vuex";
import ProductListComponent from "../components/products/list/ProductListComponent.vue";

export default {
  name: "Home",

  components: { ProductListComponent },

  computed: { ...mapGetters(["productsPaginatedData"]) },

  created() {
    this.fetchAllProducts(1);
  },

  methods: {
    ...mapActions(["fetchAllProducts"]),
  },
};
</script>
