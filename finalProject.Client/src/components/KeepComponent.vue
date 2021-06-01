<template>
  <div class="mt-4 col-3 d-flex flex-column justify-content-center align-items-center">
    <div class="img-mason pocket rounded shadow-sm">
      <div class="gradient-top">
        <img class="img-mason rounded border shadow-sm"
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
        <router-link :to="{ name: 'Profile' }">
          <div class="rounded-circle bg-light">
            <img class="img-mason rounded-circle border size-overide" :src="keepProp.creator.picture" alt="" width="30">
          </div>
        </router-link>
      </div>
    </div>

    <!-- Modal -->
    <div :class="'modal ' + 'fade ' + 'keepModal' + keepProp.id" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content border border-primary">
          <div class="modal-body">
            <div class="row">
              <div class="col col-md-5 d-flex justify-content-start">
                <div class="pocket">
                  <img class="img-modal shadow-sm rounded" :src="keepProp.img">
                  <div class="top-left">
                    <h6><i class="delete-button fas fa-edit fa-2x" data-toggle="modal" :data-target="'#EditKeep' + keepProp.id" /></h6>
                  </div>
                </div>
              </div>
              <div class="col col-md-7">
                <div class="row justify-content-end mr-3">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="row justify-content-center mb-3">
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
                <div class="row justify-content-center text-dark">
                  <h2>{{ keepProp.name }}</h2>
                </div>
                <div class="row justify-content-center mx-2 text-dark mb-4 border-bottom border-primary">
                  <p class="mx-4">
                    {{ keepProp.description }}
                  </p>
                </div>
                <div class="row justify-content-center mx-2">
                  <div class="col-5">
                    <button type="button" class="btn btn-outline-primary">
                      add to a vault
                    </button>
                  </div>
                  <div class="col-2 d-flex align-items-center">
                    <i class="delete-button fas fa-trash fa-2x text-danger" title="delete this keep" @click="deleteKeep(keepProp.id)" />
                  </div>
                  <div class="col-1 d-flex align-items-center">
                    <img class="rounded-circle" :src="keepProp.creator.picture" alt="" width="25">
                  </div>
                  <div class="col-4 d-flex align-items-center text-dark">
                    <span>{{ keepProp.creator.name }}</span>
                  </div>
                </div>
              </div>
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
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
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
      user: computed(() => AppState.user),
      newKeepEdit: {}
    })
    return {
      state,
      async deleteKeep(id) {
        try {
          if (await Notification.confirmAction('Are you sure you want to delete this bokeepard?')) {
            $('.keepModal' + props.keepProp.id).modal('hide')
            await keepsService.deleteKeep(id)
            await keepsService.getAllKeeps()
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
  }
}
// TODO functions
// Delete Keep
// Edit Keep
// Keep by id
</script>

<style scoped>
.img-modal{
 max-width: 20rem;
}
.img-mason{
  max-width: 15vw;
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

</style>
