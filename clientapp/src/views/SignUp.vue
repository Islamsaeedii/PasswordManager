<template>
    <div class="container">
        <h4 class="header">Log In</h4>
        <form  class="login">
            <input type="email" placeholder="E-mail" v-model="email">

            <input type="password" placeholder="Password" v-model="password" />

            <input type="text" placeholder="Name" v-model="name" />

            <input type="text" placeholder="User Name" v-model="username" />
          
            <button class="submit" type="submit" @click.prevent="onSubmit">submit</button>
        </form>
        <div class="register">
            <p>Don't have an account? <router-link to="/signIn">Sign In</router-link>
            </p>
        </div>
    </div>
</template>
    
<script>
import axios from 'axios';


export default {

    data(){
        return{
            notification:'bbbbbbbbb'
        }
    },
    created(){

    },
    methods: {
        onSubmit() {
            axios.post('http://localhost:5000/api/Account/register', {
                email: this.email,
                password: this.password,
                userName: this.name,
                displayName: this.username
            })
                .then(function () {
                    alert("successfuuly")
                    // this.notification=response;
                    // this.$swal
                    //     .fire({
                    //         text: "Are you sure to delete the product ?",
                    //         icon: "error",
                    //         showCancelButton: true,
                    //     })
                })
                .catch(function () {
                    // this.notification='error';
                    alert("error")
                  
                });






        },
    },
};
</script>
  
<style scoped>
.container {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 100%;
    max-width: 400px;
    padding: 20px;
    padding-top: 50px;
    padding-bottom: 50px;

    border: 1px solid #ccc;
    border-radius: 5px;
}

.header {
    text-align: center;
    font-size: 22px;
    font-weight: 700;
    margin-bottom: 20px;
}

.login {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.login input {
    width: 100%;
    margin: 10px 0;
    padding: 10px;
    padding-left: 25px;
    border: 1px solid #ccc;
    border-radius: 60px;

}

.submit {
    margin-top: 30px;
    width: 100%;
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 60px;
    /* backgrount facebook */
    background: #5138ED;
    color: #fff;
    font-weight: 700;
    cursor: pointer;
}

.register {
    margin-top: 20px;
    text-align: center;
}

.register p {
    margin-bottom: 10px;
    font-weight: 700;

}

.register a {
    color: #5138ED;
    font-size: 14px;
    font-weight: 700;
    text-decoration: none;
}

.error {
    text-align: left;
    color: red;
    font-size: 14px;
    font-weight: 500;
}
</style>
    

