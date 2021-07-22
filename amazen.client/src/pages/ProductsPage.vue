<template>
  <div class="Merchant bg-light flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container-fluid">
      <div class="row">
        <Product v-for="p in products" :key="p.id" :product="p"></Product>
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive, onMounted } from 'vue'
export default {
  setup() {
    return { products: computed(() => AppState.products) }
  }
}
</script>

<style scoped>

</style>
