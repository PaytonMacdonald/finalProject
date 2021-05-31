<template>
  <div class="mt-4 d-flex flex-column justify-content-center align-items-center">
    <div class="img-mason pocket rounded shadow-sm">
      <div class="gradient-top">
        <img class="img-mason"
             src="https://homepages.cae.wisc.edu/~ece533/images/airplane.png"
             alt=""
             data-toggle="modal"
             data-target=".bd-example-modal-lg"
             title="click for details"
             index="-1"
        >
      </div>
      <div class="bottom-left">
        <h6>Keep Title</h6>
      </div>
      <div class="bottom-right">
        <router-link :to="{ name: 'Profile' }">
          <div class="rounded-circle bg-light">
            <img class="img-mason rounded-circle border" :src="state.user.picture" alt="" width="30">
          </div>
        </router-link>
      </div>
    </div>

    <!-- Modal -->
    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content border border-primary">
          <div class="modal-body">
            <div class="row">
              <div class="col col-md-5 d-flex justify-content-start">
                <img class="img-modal shadow-sm rounded" src="https://homepages.cae.wisc.edu/~ece533/images/airplane.png" alt="">
              </div>
              <div class="col col-md-7">
                <div class="row justify-content-end mr-3">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="row justify-content-center mb-3">
                  <div class="col-3 d-flex justify-content-center align-items-center">
                    <i class="fas fa-eye text-primary" /> <span class="ml-2">0</span>
                  </div>
                  <div class="col-3 d-flex justify-content-center align-items-center">
                    <i class="fas fa-share-square text-primary" /> <span class="ml-2">0</span>
                  </div>
                  <div class="col-3 d-flex justify-content-center align-items-center">
                    <i class="fas fa-share-alt text-primary" /> <span class="ml-2">0</span>
                  </div>
                </div>
                <div class="row justify-content-center text-dark">
                  <h2>Keep Name</h2>
                </div>
                <div class="row justify-content-center mx-2 text-dark mb-4 border-bottom border-primary">
                  <p class="mx-4">
                    Lorem ipsum dolor, sit amet consectetur adipisicing elit. Quidem enim, dolores provident earum, nam voluptatibus error omnis voluptatum sapiente voluptates debitis distinctio fugiat velit, incidunt nihil? Et qui sequi voluptatibus.
                  </p>
                </div>
                <div class="row justify-content-center mx-2">
                  <div class="col-5">
                    <button type="button" class="btn btn-outline-primary">
                      add to a vault
                    </button>
                  </div>
                  <div class="col-2 d-flex align-items-center">
                    <i class="delete-button fas fa-trash fa-2x text-danger" title="delete this keep" />
                  </div>
                  <div class="col-1 d-flex align-items-center">
                    <img class="rounded-circle" :src="state.user.picture" alt="" width="25">
                  </div>
                  <div class="col-4 d-flex align-items-center">
                    <span>{{ state.user.name }}</span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'

export default {
  name: 'Keep',
  setup() {
    const state = reactive({
      user: computed(() => AppState.user)
    })
    return {
      state
    }
  }
}
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
