<template>
  <div class="container-fluid mx-2 mx-md-5">
    <div class="row mx-5 mt-5 d-flex align-items-center">
      <h1>
        {{ state.activeVault.name }}
        <span v-if="state.activeVault.creatorId == state.account.id">
          <i class="ml-3 fas fa-trash text-danger delete-button" @click="deleteVault(state.activeVault.id)" title="delete this vault" />
        </span>
      </h1>
    </div>
    <div class="row mx-2 mx-md-5 mt-2">
      <p>{{ state.activeVault.description }}</p>
    </div>
    <div class="row mx-2 mx-md-5 mt-1 border-bottom border-primary pb-4">
      <h4>keeps: {{ state.vaultKeeps.length }}</h4>
    </div>
    <div class="row mx-2 mx-md-5 mt-3">
      <!-- <div class="" v-if="state.vaultkeeps"> -->
      <div class="card-columns">
        <KeepComponent v-for="keep in state.vaultKeeps" :key="keep.id" :keep-prop="keep" />
      </div>
      <!-- </div> -->
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { reactive, computed, onMounted, watch } from 'vue'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import KeepComponent from '../components/KeepComponent'
import Notification from '../utils/Notification'

export default {
  name: 'VaultPage',
  setup() {
    const route = useRoute()
    watch(
      () => state.account,
      async x => {
        await vaultsService.getVaultById(route.params.id)
      }
    )
    const state = reactive({
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      vaultKeeps: computed(() => AppState.vaultKeeps),
      activeVault: computed(() => AppState.activeVault),
      activeProfile: computed(() => AppState.activeProfile)
    })
    onMounted(async() => {
      try {
        await keepsService.getKeepsByVaultId(route.params.id)
      } catch (error) {
        Notification.toast('Error:' + error, 'error')
      }
    })
    return {
      state,
      async deleteVault(id) {
        try {
          if (await Notification.confirmAction('Are you sure you want to delete this vault?')) {
            await vaultsService.deleteVault(id)
            Notification.toast('Keep Deleted', 'success')
          }
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
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
