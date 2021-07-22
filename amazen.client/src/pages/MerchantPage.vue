<template>
  <div class="Merchant bg-light flex-grow-1 d-flex flex-column align-items-center">
    <div class="container-fluid">
      <div class="row justify-content-center">
        <form class="form-group col-md-8" @submit.prevent="createMerchant">
          <h3 class="mb-3">
            Create A Merchant
          </h3>
          <hr>
          <input type="text"
                 class="form-control "
                 name="merchantName"
                 id=""
                 aria-describedby="helpId"
                 placeholder=""
                 v-model="state.newMerchant.name"
          >
          <small id="helpId" class="form-text text-muted mb-2">Merchant Name</small>
          <input type="text"
                 class="form-control"
                 name="merchantName"
                 id=""
                 aria-describedby="helpId"
                 placeholder=""
                 v-model="state.newMerchant.category"
          >
          <small id="helpId" class="form-text text-muted">Category</small>
          <button class="mt-5 btn btn-block btn-info">
            Create
          </button>
        </form>
        <div class="col-md-8">
          <div class="row justify-content-center">
            <div class="col-8 bg-dark rounded shadow text-light p-4 text-center">
              <h3>{{ activeMerchant.name }}</h3>
              <hr>
              <h4>{{ activeMerchant.category }}</h4>
            </div>
          </div>
        </div>
      </div>
      <div v-if="products.length > 0" class="row mt-5">
        <h5 class="col-12 text-center text-info">
          {{ activeMerchant.name }}'s Products
        </h5>
        <Product v-for="p in products" :key="p.id" :product="p" />
      </div>
      <div class="col-12" v-else>
        this merchant doesnt have any products yet or they are loading
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive, onMounted, watchEffect } from 'vue'
import { merchantService } from '../services/MerchantService'
import { useRoute } from 'vue-router'
import { productService } from '../services/ProductService'
export default {
  setup() {
    const route = useRoute()
    const state = reactive({
      newMerchant: {}
    })
    watchEffect(() => {
      merchantService.getMerchant(route.params.id)
      productService.getProductsByMerchantId(route.params.id)
    })
    return {
      state,
      activeMerchant: computed(() => AppState.activeMerchant),
      products: computed(() => AppState.products),
      createMerchant() {
        merchantService.createMerchant(state.newMerchant)
      }
    }
  }
}
</script>

<style scoped>

</style>
