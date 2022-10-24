<template>
  <div class="container">
    <div class="card">
      <div class="card-header">
        <h6>Edit Info</h6>
        <form  class="login">
            <input type="email" placeholder="E-mail" v-model="accounts.email">

            <input type="password" placeholder="Password" v-model="accounts.password" />

            <input type="text" placeholder="url" v-model="accounts.url" />

            <input type="text" placeholder="description" v-model="accounts.description" />
          
            <button class="submit" type="submit" @click.prevent="onSubmit">submit</button>
        </form>
      </div>
      
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";


export default {
  components: {
 
  },


  data() {
    return {
      id: null,
      accounts:{
        email:'',
        url:'',
        password:'',
        description:''
      }
    };
  },

  computed: {
    ...mapGetters(["isUpdating", "updatedData", "product", "isLoading"]),
  },

  watch: {
    updatedData: function () {
      if (this.updatedData !== null && !this.isUpdating) {
        this.$swal.fire({
          text: "Success, Product has been updated successfully !",
          icon: "success",
          position: "top-end",
          timer: 1000,
        });

        this.$router.push({ name: "Products" });
      }
    },
  },

  created: function () {
    this.id = this.$route.params.id;
    this.fetchDetailProduct(this.id);
  },

  methods: {
    ...mapActions([
      "updateProduct",
      "updateProductInput",
      "fetchDetailProduct",
    ]),
    onSubmit() {
      // return false;
      this.updateProduct({
        email: this.accounts.email,
        password: this.accounts.password,
        url: this.accounts.url,
        description: this.accounts.description,
        id:this.$route.params.id 
        
      });
    },
    updateProductInputAction(e) {
      this.updateProductInput(e);
    },
  },
};
</script>
