<template>
  <div class="container-fluid mx-md-5 mt-4">
    <div class="row border-bottom border-primary pb-5 mx-2 mx-md-5">
      <div class="col col-md-1 d-flex justify-content-center justify-content-md-start align-items-center">
        <img class="rounded shadow border" :src="state.activeProfile.picture" alt="Profile Picture">
      </div>
      <div class="col ml-md-5">
        <h2 class="">
          {{ state.activeProfile.name }}
        </h2>
        <h4 class="text-white">
          Vaults: {{ state.vaults.length }}
        </h4>
        <h4 class="text-white">
          Keeps: {{ state.keeps.length }}
        </h4>
      </div>
    </div>
    <div class="row mt-4 mx-2 mx-md-5">
      <h1 class="text-white">
        VAULTS
        <span class="" v-if="state.activeProfile.id == state.account.id">
          <i class="fas fa-plus text-primary add-thing" data-toggle="modal" data-target="#NewVault" title="add a new vault" />
        </span>
      </h1>
    </div>
    <div class="row mx-2 mx-md-5 border-bottom border-primary pb-5">
      <VaultComponent v-for="vault in state.vaults" :key="vault.id" :vault-prop="vault" />
    </div>
    <div class="row mt-4 mx-2 mx-md-5">
      <h1 class="text-white">
        Keeps
        <span class="" v-if="state.activeProfile.id == state.account.id">
          <i class="fas fa-plus text-primary add-thing" data-toggle="modal" data-target="#NewKeep" title="add a new keep" />
        </span>
      </h1>
    </div>
    <div class="row mx-2 mx-md-5 pb-5 mb-5">
      <div class="card-columns">
        <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
      </div>
    </div>
    <!-- MODAL FORM 1 KEEPS -->
    <div class="modal fade"
         id="NewKeep"
         tabindex="-1"
         role="dialog"
         aria-labelledby="NewKeepLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content  border border-primary">
          <div class="modal-header bg-primary">
            <h2 class="modal-title" id="NewKeepLabel">
              New Keep
            </h2>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <!-- TODO setup the @submit.prevent and the v-models -->
          <form @submit.prevent="createKeep">
            <div class="modal-body">
              <div class="form-group text-dark">
                <label for="keepTitle">New Title</label>
                <input type="text"
                       class="form-control"
                       id="keepTitle"
                       aria-describedby="emailHelp"
                       placeholder="New Title..."
                       v-model="state.newKeep.name"
                >
              </div>
              <div class="form-group text-dark">
                <label for="keepImgUrl">New Image URL</label>
                <input type="text"
                       class="form-control"
                       id="keepImgUrl"
                       aria-describedby="emailHelp"
                       placeholder="New URL..."
                       v-model="state.newKeep.img"
                >
              </div>
              <div class="form-group text-dark">
                <label for="keepDescription">New Description</label>
                <textarea class="form-control" id="keepDescription" rows="3" placeholder="New Description..." v-model="state.newKeep.description"></textarea>
              </div>
            </div>
            <div class="modal-footer">
              <button type="submit" class="btn btn-primary">
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
    <!-- END MODAL -->
    <!-- MODAL FORM 2 VAULTS -->
    <div class="modal fade"
         id="NewVault"
         tabindex="-1"
         role="dialog"
         aria-labelledby="NewVaultLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content  border border-primary">
          <div class="modal-header bg-primary">
            <h2 class="modal-title" id="NewVaultLabel">
              New Vault
            </h2>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="createVault">
            <div class="modal-body">
              <div class="form-group text-dark">
                <label for="vaultTitle">Title</label>
                <input type="text"
                       class="form-control"
                       id="vaultTitle"
                       aria-describedby="emailHelp"
                       placeholder="Title..."
                       v-model="state.newVault.name"
                >
              </div>
              <div class="form-group text-dark">
                <label for="vaultDescription">Description</label>
                <textarea class="form-control" id="vaultDescription" rows="3" placeholder="Description..." v-model="state.newVault.description"></textarea>
              </div>
              <!-- TODO private option needs to work -->
              <div class="form-check text-dark">
                <input type="checkbox" class="form-check-input" id="privateVault" @click="formCheckBox">
                <label class="form-check-label" for="privateVault">Make This Vault Private</label>
              </div>
            </div>
            <div class="modal-footer">
              <button type="submit" class="btn btn-primary">
                Submit
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
    <!-- END MODAL -->
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { reactive, computed, onMounted } from 'vue'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
import VaultComponent from '../components/VaultComponent'
import KeepComponent from '../components/KeepComponent'
import Notification from '../utils/Notification'
import $ from 'jquery'

// import router from '../router.js' // NOTE use this if you need to auto push somewhere

export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      activeProfile: computed(() => AppState.activeProfile),
      privateCheck: false,
      newVault: { isPrivate: false },
      newKeep: {}
    })
    onMounted(async() => {
      try {
        await profilesService.getProfileById(route.params.id)
        await keepsService.getKeepsByProfileId(route.params.id)
        await vaultsService.getVaultsByProfileId(state.activeProfile.id)
      } catch (error) {
        Notification.toast('That did not work: ' + error, 'error')
      }
    })
    return {
      route,
      state,
      async createKeep() {
        try {
          await keepsService.createKeep(state.newKeep)
          state.newKeep = {}
          Notification.toast('Keep Created!', 'success')
          $('#NewKeep').modal('hide')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      },
      async createVault() {
        try {
          await vaultsService.createVault(state.newVault)
          state.newVault = {}
          await vaultsService.getVaultsByProfileId(route.params.id, state.account.id)
          $('#NewVault').modal('hide')
          Notification.toast('Vault Created!', 'success')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      },
      formCheckBox() {
        if (state.privateCheck === false) {
          state.privateCheck = true
          state.newVault.isPrivate = true
          return state.privateCheck
        }
        state.privateCheck = false
        state.newVault.isPrivate = false
        return state.privateCheck
      }
    }
  },
  components: {
    VaultComponent,
    KeepComponent
  }
}
// TODO functions
// Get Profile
// Create Get Vaults by Profile Id
// Get Keeps by Profile Id
</script>

<style scoped>
.add-thing:hover{
opacity: 50%;
cursor: pointer;
}
</style>
