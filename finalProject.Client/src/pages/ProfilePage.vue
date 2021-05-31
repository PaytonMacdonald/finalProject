<template>
  <div class="container-fluid mx-5 mt-5">
    <div class="row border-bottom border-primary pb-5 mx-5">
      <div class="col-1 d-flex align-items-center">
        <img class="rounded" :src="state.user.picture" alt="">
      </div>
      <div class="col ml-5">
        <h2 class="">
          {{ state.user.name }}
        </h2>
        <h4 class="text-white">
          Vaults: 0
        </h4>
        <h4 class="text-white">
          Keeps: 0
        </h4>
      </div>
    </div>
    <div class="row mt-4 mx-5">
      <h1 class="text-white">
        VAULTS <i class="fas fa-plus text-primary add-thing" data-toggle="modal" data-target="#NewVault" title="add a new vault" />
      </h1>
    </div>
    <div class="row mx-5 border-bottom border-primary pb-5">
      <VaultComponent />
    </div>
    <div class="row mt-4 mx-5">
      <h1 class="text-white">
        Keeps <i class="fas fa-plus text-primary add-thing" data-toggle="modal" data-target="#NewKeep" title="add a new keep" />
      </h1>
    </div>
    <div class="row mx-5 pb-5 mb-5">
      <KeepComponent />
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
          <form>
            <div class="modal-body">
              <div class="form-group text-dark">
                <label for="vaultTitle">Title</label>
                <input type="email" class="form-control" id="vaultTitle" aria-describedby="emailHelp" placeholder="Title...">
              </div>
              <div class="form-group text-dark">
                <label for="vaultDescription">Description</label>
                <textarea class="form-control" id="vaultDescription" rows="3" placeholder="Description..."></textarea>
              </div>
              <div class="form-check text-dark">
                <input type="checkbox" class="form-check-input" id="privateVault">
                <label class="form-check-label" for="privateVault">Private Vault</label>
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
import { computed, reactive } from 'vue'
import VaultComponent from '../components/VaultComponent'
import KeepComponent from '../components/KeepComponent'

export default {
  name: 'ProfilePage',
  setup() {
    const state = reactive({
      user: computed(() => AppState.user)
    })
    return {
      state
    }
  },
  components: {
    VaultComponent,
    KeepComponent
  }
}
</script>

<style scoped>
.add-thing:hover{
opacity: 50%;
cursor: pointer;
}
</style>
