<template>
  <div class="align-items-center justify-content-center">
    <div class="card">
      <img class="img-mason card-img-top"
           :src="keepProp.img"
           alt="keep image"
           data-toggle="modal"
           :data-target="'.keepModal' + keepProp.id"
           title="click for details"
      >
      <div class="bottom-left">
        <h3>{{ keepProp.name }}</h3>
      </div>
      <div class="bottom-right">
        <div class="rounded bg-light">
          <router-link :to="{ name: 'ProfilePage', params: {id: keepProp.creator.id}}">
            <img class="img-mason rounded border size-overide" :src="keepProp.creator.picture" alt="" width="50">
          </router-link>
        </div>
      </div>
    </div>
    <!-- <div class="img-mason pocket rounded shadow-sm">
      <div class="card-img-top gradient-top">
        <img class="img-mason rounded border shadow"
             :src="keepProp.img"
             alt=""
             data-toggle="modal"
             :data-target="'.keepModal' + keepProp.id"
             title="click for details"
             index="-1"
        >
      </div>
      <div class="bottom-left">
        <h6>{{ keepProp.name }}</h6>
      </div>
      <div class="bottom-right">
        <div class="rounded bg-light">
          <router-link :to="{ name: 'ProfilePage', params: {id: keepProp.creator.id}}">
            <img class="img-mason rounded border size-overide" :src="keepProp.creator.picture" alt="" width="30">
          </router-link>
        </div>
      </div>
    </div> -->

    <!-- Modal -->
    <div :class="'modal ' + 'fade ' + 'keepModal' + keepProp.id" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog big-modal">
        <div class="modal-content border border-primary">
          <div class="modal-body">
            <div class="row justify-content-end mr-2 mb-3 desktop-gone">
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="row">
              <!-- SECTION IMAGE -->
              <div class="col col-md-5 d-flex justify-content-center justify-content-md-start">
                <img class="img-modal shadow-sm rounded" :src="keepProp.img">
                <div class="top-left">
                  <h6><i class="delete-button fas fa-edit fa-2x text-primary pl-2" data-toggle="modal" :data-target="'#EditKeep' + keepProp.id" /></h6>
                </div>
                <div class="bottom-left">
                  <div v-if="keepProp.creatorId == state.account.id && keepProp.vaultKeepId != null">
                    <button type="button" class="btn btn-dark btn-sm ml-md-2" @click="deleteVaultKeep(keepProp.vaultKeepId)">
                      remove from vault
                    </button>
                  </div>
                </div>
              </div>
              <!-- SECTION CONTENT -->
              <div class="col d-flex flex-column justify-content-between">
                <div class="row ">
                  <div class="col">
                    <div class="row justify-content-end mr-3 mobile-gone">
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                      </button>
                    </div>
                    <div class="row justify-content-center mt-3 mt-md-0 mr-0">
                      <div class="col-3 d-flex justify-content-center align-items-center">
                        <i class="fas fa-eye text-primary" /> <span class="ml-2 text-primary">0</span>
                      </div>
                      <div class="col-3 d-flex justify-content-center align-items-center">
                        <i class="fas fa-share-square text-primary" /> <span class="ml-2 text-primary">0</span>
                      </div>
                      <div class="col-3 d-flex justify-content-center align-items-center">
                        <i class="fas fa-share-alt text-primary" /> <span class="ml-2 text-primary">0</span>
                      </div>
                    </div>
                    <div class="row justify-content-center text-dark mt-2 mr-0">
                      <h2>{{ keepProp.name }}</h2>
                    </div>
                    <div class="row justify-content-center mx-2 text-dark mb-4 mr-0">
                      <p class="mx-4">
                        {{ keepProp.description }}
                      </p>
                    </div>
                  </div>
                </div>
                <div class="row align-items-start">
                  <div class="col d-flex align-items-start">
                  </div>
                </div>
                <div class="row border-top border-primary mx-3 pt-3">
                  <div class="col d-flex justify-content-center justify-content-md-start align-items-end pb-3 pb-md-0">
                    <div class="dropdown">
                      <button class="btn btn-primary dropdown-toggle w-100"
                              type="button"
                              id="dropdownMenuButton"
                              data-toggle="dropdown"
                              aria-haspopup="true"
                              aria-expanded="false"
                      >
                        add to vault
                      </button>
                      <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                        <div class="ml-2" v-for="vault in state.vaults" :key="vault.id" @click="createVaultKeep(vault.id)">
                          <a href="#">{{ vault.name }}</a>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-2 d-flex justify-content-center align-items-end">
                    <div v-if="keepProp.creatorId == state.account.id">
                      <i class="delete-button fas fa-trash fa-2x text-danger" title="delete this keep" @click="deleteKeep(keepProp.id)" />
                    </div>
                  </div>
                  <div class="col d-flex justify-content-center justify-content-md-end align-items-end">
                    <div class="row justify-content-center">
                      <div class="col">
                        <router-link :to="{ name: 'ProfilePage', params: {id: keepProp.creator.id}}"
                                     data-dismiss="modal"
                                     :data-target="'.keepModal' + keepProp.id"
                        >
                          <img class="img-mason rounded border mr-2" :src="keepProp.creator.picture" alt="keep image" width="30" :title="keepProp.creator.name">
                        </router-link>
                        <router-link :to="{ name: 'ProfilePage', params: {id: keepProp.creator.id}}"
                                     data-dismiss="modal"
                                     :data-target="'.keepModal' + keepProp.id"
                        >
                          <span>{{ keepProp.creator.name }}</span>
                        </router-link>
                      </div>
                    </div>
                  </div>
                </div>
              <!--
                <div class="row align-content-end justify-content-between pr-4 mx-2">
                  <div class="col">
                  </div>
                </div>
                <div class="row justify-content-start mx-4 mt-3">
                  <div v-if="keepProp.creatorId == state.account.id && keepProp.vaultKeepId != null">
                    <button type="button" class="btn btn-warning" @click="deleteVaultKeep(keepProp.vaultKeepId)">
                      remove from vault
                    </button>
                  </div>
              </div> -->
              <!-- SECTION -->
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- MODAL FORM 1 KEEPS -->
      <div class="modal fade"
           :id="'EditKeep' + keepProp.id"
           tabindex="-1"
           role="dialog"
           aria-labelledby="NewKeepLabel"
           aria-hidden="true"
      >
        <div class="modal-dialog" role="document">
          <div class="modal-content  border border-primary">
            <div class="modal-header bg-primary">
              <h2 class="modal-title" id="NewKeepLabel">
                Edit Keep
              </h2>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <form>
              <div class="modal-body">
                <div class="form-group text-dark">
                  <label for="keepTitle">Title</label>
                  <input type="email" class="form-control" id="keepTitle" aria-describedby="emailHelp" placeholder="Title...">
                </div>
                <div class="form-group text-dark">
                  <label for="keepImgUrl">Image URL</label>
                  <input type="email" class="form-control" id="keepImgUrl" aria-describedby="emailHelp" placeholder="URL...">
                </div>
                <div class="form-group text-dark">
                  <label for="keepDescription">Description</label>
                  <textarea class="form-control" id="keepDescription" rows="3" placeholder="Description..."></textarea>
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
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { vaultkeepsService } from '../services/VaultKeepsService'
import Notification from '../utils/Notification'
import $ from 'jquery'

export default {
  name: 'Keep',
  props: {
    keepProp: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      newVaultKeep: {}
    })
    return {
      state,
      async createVaultKeep(id) {
        try {
          state.newVaultKeep = { vaultId: id, keepId: props.keepProp.id }
          await vaultkeepsService.createVaultKeep(state.newVaultKeep)
          Notification.toast('Keep Added to Vault!', 'success')
          $('.keepModal' + props.keepProp.id).modal('hide')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      },
      async deleteVaultKeep(id) {
        try {
          if (await Notification.confirmAction('Are you sure you want to delete this keep?')) {
            $('.keepModal' + props.keepProp.id).modal('hide')
            await vaultkeepsService.deleteVaultKeep(id)
            Notification.toast('Keep Deleted', 'success')
          }
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      },
      async deleteKeep(id) {
        try {
          if (await Notification.confirmAction('Are you sure you want to delete this keep?')) {
            $('.keepModal' + props.keepProp.id).modal('hide')
            await keepsService.deleteKeep(id)
            Notification.toast('Keep Deleted', 'success')
          }
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      },
      async editKeep() {
        try {
          await keepsService.editKeep(state.newKeepName, props.keepProp.id)
          state.newKeepEdit = {}
          Notification.toast('Keep Updated!', 'success')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  },
  components: {
    // AddToVaultComponent
  }
}
// TODO FUNCTIONS NEEDED
// Get Vaults By Profile ID
// Edit Keep
</script>

<style scoped>
.img-modal{
max-width: 20rem;
}
.img-mason:hover{
  opacity: 80%;
  cursor: pointer;
}
.delete-button:hover{
  opacity: 80%;
  cursor: pointer;
}
.pocket {
  position: relative;
  text-align: center;
  color: white;
}
.gradient-top{
  background: linear-gradient(transparent, transparent, var(--dark));
}
.top-left {
  position: absolute;
  top: 0.75rem;
  left: 1rem;
}
.bottom-left {
  position: absolute;
  bottom: 0.75rem;
  left: 1rem;
}
.bottom-right {
  position: absolute;
  bottom: 0.75rem;
  right: 1rem;
}
h6{
  padding: 0;
  margin: 0;
}
.invisible{
opacity: 0;
}
.big-modal{
  max-width: 60vw;
}
@media only screen and (max-width: 600px) {
.big-modal{
  max-width: 100vw;
}
.mobile-gone{
display: none;
}
}
@media only screen and (min-width: 600px) {
.desktop-gone{
display: none;
}
}

</style>
