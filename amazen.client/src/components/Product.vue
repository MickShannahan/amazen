<template>
  <div class="Product col-4">
    <div class="row p-3">
      <h5 class="col-8">
        {{ product.name }}
      </h5>
      <router-link :to="{name: 'Merchant', params:{id: product.merchantId}}">
        <b class="col-4">{{ product.merchant.name }}</b>
      </router-link>
      <div class="col-12">
        <img class="img-fluid" :src="product.imgUrl" alt="">
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive, onMounted } from 'vue'
export default {
  props: {
    product: { type: Object, required: true }
  },
  setup() {
    const state = reactive({

    })
    return { state }
  }
}
</script>

<style scoped>

</style>
