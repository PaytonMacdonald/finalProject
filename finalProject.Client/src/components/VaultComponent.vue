<template>
  <div class="mt-4 d-flex flex-column justify-content-center align-items-center">
    <router-link :to="{ name: 'VaultPage', params: {id: vaultProp.id}}" class="nav-link">
      <div class="img-mason pocket rounded shadow-sm">
        <div class="gradient-top">
          <img class="img-mason rounded border shadow"
               src="https://homepages.cae.wisc.edu/~ece533/images/airplane.png"
               alt=""
               title="click to view this vault"
          >
        </div>
        <div class="bottom-left">
          <h3>{{ vaultProp.name }}</h3>
        </div>
      </div>
    </router-link>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'

export default {
  name: 'Vault',
  props: {
    vaultProp: {
      type: Object,
      required: true
    }
  },
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
