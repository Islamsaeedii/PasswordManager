// import { GET_ALL_PRODUCTS } from "./Types";
import axios from 'axios';
import Cookies from 'js-cookie'
// initial state
const state = () => ({
  products: [],
  productsPaginatedData: null,
  product: null,
  isLoading: false,
  isCreating: false,
  createdData: null,
  isUpdating: false,
  updatedData: null,
  isDeleting: false,
  deletedData: null,
  isLoging: false
})

// getters
const getters = {
  productList: state => state.products,
  productsPaginatedData: state => state.productsPaginatedData,
  product: state => state.product,
  isLoading: state => state.isLoading,
  isCreating: state => state.isCreating,
  isUpdating: state => state.isUpdating,
  createdData: state => state.createdData,
  updatedData: state => state.updatedData,
  isLoging: state => state.isLoging,
  isDeleting: state => state.isDeleting,
  deletedData: state => state.deletedData
};

// actions
const actions = {
  async fetchAllProducts({ commit }) {
    // let page = 1;
    // // let search = '';
    // if(query !== null){
    //   page = query?.page || 1;
    //   // search = query?.search || '';
    // }

    commit('setProductIsLoading', true);
    // let url = `${process.env.VUE_APP_API_URL}products?page=${page}`;
    let url = `http://localhost:5000/api/User/${Cookies.get('userId')}`;
    // if (search === null) {
    //   url = `${url}?page=${page}`;
    // } else {
    //   url = `${process.env.VUE_APP_API_URL}products/view/search?search=${search}&page=${page}`
    // }

    await axios.get(url)
      .then(res => {
        const products = res.data;
        // const products = res.data.data.data;
        commit('setProducts', products);
        const pagination = {
          total: res.data.data.total,  // total number of elements or items
          per_page: res.data.data.per_page, // items per page
          current_page: res.data.data.current_page, // current page (it will be automatically updated when users clicks on some page number).
          total_pages: res.data.data.last_page // total pages in record
        }
        res.data.data.pagination = pagination;
        commit('setProductsPaginated', res.data.data);
        commit('setProductIsLoading', false);
      }).catch(err => {
        console.log('error', err);
        commit('setProductIsLoading', false);
      });
  },

  async fetchDetailProduct({ commit }, id) {
    commit('setProductIsLoading', true);
    await axios.get(`${process.env.VUE_APP_API_URL}products/${id}`)
      .then(res => {
        commit('setProductDetail', res.data.data);
        commit('setProductIsLoading', false);
      }).catch(err => {
        console.log('error', err);
        commit('setProductIsLoading', false);
      });
  },

  async storeProduct({ commit }, informations) {
    commit('setProductIsCreating', true);
    await axios.post(`http://localhost:5000/api/Information`,
      {
        url: informations.url,
        email: informations.email,
        password: informations.password,
        description: informations.description
      }
    )
      .then(res => {
        console.log("res of create", res)
        // commit('saveNewProducts', res.data.data);
        // commit('setProductIsCreating', false);
      }).catch(err => {
        console.log('error', err);
        commit('setProductIsCreating', false);
      });
  },

  async storeAccount({ commit }, accounts) {
    await axios.post('http://localhost:5000/api/Account/login', {
      email: accounts.email,
      password: accounts.password,
    })
      .then(res => {
        commit('setIsLogin', true);
        Cookies.set('token', res.data.token);
        Cookies.set('userId', res.data.userId);
      }).catch(err => {
        commit('setIsLogin', false);
        console.log('error post', err);
        Cookies.set('Id', null);
        commit('setProductIsCreating', false);
      });
  },



  async updateProduct({ commit }, accounts) {
    commit('setProductIsUpdating', true);
    commit('setProductIsUpdating', true);
    
    await axios.put(`http://localhost:5000/api/Information/${accounts.id}`, 
    {
      email: accounts.email,
      password: accounts.password,
      url: accounts.url,
      description: accounts.description,
    })
      .then(res => {
        commit('saveUpdatedProduct', res.data.data);
        commit('setProductIsUpdating', false);
      }).catch(err => {
        console.log('error fetch all data', err);
        commit('setProductIsUpdating', false);
      });
  },


  async deleteProduct({ commit }, id) {
    commit('setProductIsDeleting', true);

    await axios.delete(`http://localhost:5000/api/Information/${id}`,
      {
        headers: {
          'Content-Type': 'application/json',
        }
      }
    )
      // await axios.delete(`${process.env.VUE_APP_API_URL}products/${id}`)
      .then(res => {
        commit('setDeleteProduct', res.data);
        commit('setProductIsDeleting', false);
      })
      .then(response => {
        console.log(response)
        location.reload()
      }

      )
      .catch(err => {
        console.log('error delete item', err);
        commit('setProductIsDeleting', false);
      });
  },

  updateProductInput({ commit }, e) {
    commit('setProductDetailInput', e);
  }
}

// mutations
const mutations = {
  setProducts: (state, products) => {
    state.products = products
  },

  setProductsPaginated: (state, productsPaginatedData) => {
    state.productsPaginatedData = productsPaginatedData
  },

  setProductDetail: (state, product) => {
    state.product = product
  },

  setDeleteProduct: (state, id) => {
    state.productsPaginatedData.data.filter(x => x.id !== id);
  },

  setProductDetailInput: (state, e) => {
    let product = state.product;
    product[e.target.name] = e.target.value;
    state.product = product
  },

  saveNewProducts: (state, product) => {
    state.products.unshift(product)
    state.createdData = product;
  },

  saveUpdatedProduct: (state, product) => {
    state.products.unshift(product)
    state.updatedData = product;
  },

  setProductIsLoading(state, isLoading) {
    state.isLoading = isLoading
  },

  setProductIsCreating(state, isCreating) {
    state.isCreating = isCreating
  },

  setProductIsUpdating(state, isUpdating) {
    state.isUpdating = isUpdating
  },
  setIsLogin(state, isLoging) {
    state.isLoging = isLoging
  },
  setProductIsDeleting(state, isDeleting) {
    state.isDeleting = isDeleting
  },

}

export default {
  // namespaced: true,
  state,
  getters,
  actions,
  mutations
}