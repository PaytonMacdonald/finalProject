<template>
  <div class="container-fluid mx-md-5 mt-4">
    <div class="row mx-3 mx-md-5">
      <div class="card-columns">
        <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import KeepComponent from '../components/KeepComponent'
import { reactive, computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import Notification from '../utils/Notification'

export default {
  name: 'HomePage',
  setup() {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account)
    })
    onMounted(async() => {
      try {
        await keepsService.getAllKeeps()
      } catch (error) {
        Notification.toast('Error:' + error, 'error')
      }
    })
    return {
      state
    }
  },
  components: {
    KeepComponent
  }
}
// TODO functions
// Get ALL keeps
</script>

<style scoped>

</style>
