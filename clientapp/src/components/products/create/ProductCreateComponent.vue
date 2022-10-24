<!-- eslint-disable vue/html-indent -->
<template>
  <div class="container">

    <!-- <form v-on:submit.prevent="onSaveProduct" :validation-schema="schema"> -->
    <form @submit.prevent="onSubmit">
      <!-- <Form @submit="onSaveProduct" :validation-schema="schema"> -->
      <div class="form-group">
        <label>URL:</label>
        <input type="url" required v-model="informations.url" />
      </div>

      <div class="form-group">
        <label>Email:</label>
        <input type="email" required v-model="informations.email">
      </div>

      <div class="form-group">
        <label>Password:</label>
        <input type="password" required v-model="informations.password" />
      </div>


      <div class="form-group">
        <label>Description:</label>
        <textarea required v-model="informations.description" />
        <!-- <input type="text" v-model="informations.description" /> -->
      </div>
      <button class="submit" type="submit">submit</button>
    </form>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";

export default {



  data() {
    return {
      informations: {
        url: "",
        email: "",
        password: "",
        description: ""
      },
    };
  },

  computed: { ...mapGetters(["isCreating", "createdData"]) },

  watch: {
    createdData: function () {
      if (this.createdData !== null && !this.isCreating) {
        this.$swal.fire({
          text: "Success, Product has been added.",
          icon: "success",
          position: "top-end",
          timer: 1000,
        });

        this.$router.push({ name: "Products" });
      }
    },
  },

  methods: {
    ...mapActions(["storeProduct"]),
    onSubmit() {
      this.storeProduct({
        url: this.informations.url,
        email: this.informations.email,
        password: this.informations.password,
        description: this.informations.description
      });

      // route to products
      this.$router.push({ name: "Info" });
    },
  },
};
</script>


<style scoped>
.container {
  width: 100%;
  max-width: 400px;
  padding: 20px;
  padding-top: 50px;
  padding-bottom: 50px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.form-group {
  margin-bottom: 2rem;
}

.form-group label {
  display: block;
  margin-bottom: 0.5rem;
  font-size: 0.9rem;
  font-weight: 600;
}

.form-group input {
  display: block;
  width: 100%;
  padding: 0.375rem 0.75rem;
  font-size: 1rem;
  line-height: 1.5;
  color: #495057;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid #ced4da;
  border-radius: 0.25rem;
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}

.submit {
  /* in center */
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 40%;
  padding: 0.375rem 0.75rem;
  font-size: 1rem;
  line-height: 1.5;
  color: #fff;
  background-color: #5138ED;
  border: none;
  border-radius: 0.25rem;
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}

textarea {
  width: 100%;
  height: 100px;
  padding: 0.375rem 0.75rem;
  font-size: 1rem;
  line-height: 1.5;
  color: #495057;
  background-color: #fff;
  background-clip: padding-box;
  border: 1px solid #ced4da;
  border-radius: 0.25rem;
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
  resize: none;
}
</style>