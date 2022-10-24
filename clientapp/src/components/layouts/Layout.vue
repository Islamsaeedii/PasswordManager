<template>
  <div id="layout">
    <!-- if is this.isLoging show header else hide -->
    <!-- <div v-if="isLoging">
    <HeaderPartial />
  </div> -->
  <div class="main-content">
    <div class="container mt-3">
      <router-view />
    </div>
  </div>
  <FooterPartial />
  </div>
</template>

<script>
import FooterPartial from "./footer/FooterPartial";
// import HeaderPartial from "./header/HeaderPartial";

export default {
  name: "Layout",
  computed: {
    isLoging() {
      return this.$store.getters.isLoging;
    },
  },
  components: {
    // HeaderPartial,
    FooterPartial,
  },
};
</script>
