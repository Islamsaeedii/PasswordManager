<template>

  <div class="card-header">
    <h6>Edit Information</h6>
    <form class="login">
      <input  type="email" required placeholder="E-mail" v-model="accounts.email">

      <input type="password" required placeholder="Password" v-model="accounts.password" />

      <input type="text" required placeholder="url" v-model="accounts.url" />

      <input type="text" required placeholder="description" v-model="accounts.description" />

      <button class="submit" type="submit" @click.prevent="onSubmit">Save</button>
    </form>

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
      accounts: {
        email: '',
        url: '',
        password: '',
        description: ''
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
          text: "Success, Information has been updated successfully !",
          icon: "success",
          position: "top",
          timer: 1000,
        });

        this.$router.push({ name: "info" });
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
        id: this.$route.params.id
      });
      this.$router.push({ name: "Info" });
    },
    updateProductInputAction(e) {
      this.updateProductInput(e);
    },
  },
};
</script>


<style scoped>
card-header {
  background-color: #f8f9fa;
  border-bottom: 1px solid #dee2e6;
  border-top-left-radius: calc(0.25rem - 1px);
  border-top-right-radius: calc(0.25rem - 1px);
  display: flex;
  justify-content: space-between;
  padding: 0.75rem 1.25rem;
}

h6 {
  text-align: center;
  font-weight: 700;
  font-size: 25px;
  padding-top: 40px;
}

form {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 20px;
}

input {
  width: 400px;
  height: 40px;
  border: 1px solid #ccc;
  border-radius: 5px;
  margin-bottom: 15px;
  padding: 0 10px;
}

.submit {
  width: 200px;
  height: 40px;
  border: none;
  border-radius: 5px;
  background-color: #5138ED;
  color: #fff;
  font-weight: 700;
  cursor: pointer;
  margin-top: 10px;
}
</style>