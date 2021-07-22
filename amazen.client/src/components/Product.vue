<template>
  <div class="Product col-4 p-3">
    <div class="row">
      <div class="col-12">
        <h5>
          {{ product.name }}
        </h5>
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
