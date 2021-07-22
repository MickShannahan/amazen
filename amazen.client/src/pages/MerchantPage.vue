<template>
  <div class="Merchant bg-light flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container-fluid">
      <div class="row">
        <form class="form-group col-md-5" @submit.prevent="createMerchant">
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
        <div class="col-md-7">
          <div class="row justify-content-center">
            <div class="col-8 bg-dark rounded shadow text-light p-4 text-center">
              <h3>{{ activeMerchant.name }}</h3>
              <hr>
              <h4>{{ activeMerchant.category }}</h4>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive, onMounted } from 'vue'
import { merchantService } from '../services/MerchantService'
export default {
  setup() {
    const state = reactive({
      newMerchant: {}
    })
    return {
      state,
      activeMerchant: computed(() => AppState.activeMerchant),
      createMerchant() {
        merchantService.createMerchant(state.newMerchant)
      }
    }
  }
}
</script>

<style scoped>

</style>
