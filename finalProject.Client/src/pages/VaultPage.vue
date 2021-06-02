<template>
  <div class="container-fluid mx-5">
    <div class="row mx-5 mt-5 d-flex align-items-center">
      <h1>{{ state.activeVault.name }} <i class="ml-3 fas fa-trash text-danger delete-button" /></h1>
    </div>
    <div class="row mx-5 mt-1 border-bottom border-primary pb-4">
      <h4>keeps: 0</h4>
    </div>
    <div class="row mx-5 mt-3">
      <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { reactive, computed, onMounted } from 'vue'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import KeepComponent from '../components/KeepComponent'
import Notification from '../utils/Notification'

export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      user: computed(() => AppState.user),
      keeps: computed(() => AppState.keeps),
      activeVault: computed(() => AppState.activeVault)
    })
    onMounted(async() => {
      try {
        await keepsService.getKeepsByVaultId(state.activeVault.id)
        await vaultsService.getVaultById(route.params.id)
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
// Delete Vault
// Edit Vault
// Get VaultKeeps
</script>

<style scoped>
.delete-button:hover{
  opacity: 80%;
  cursor: pointer;
}
</style>
