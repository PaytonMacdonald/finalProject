<template>
  <div class="container-fluid mx-5 mt-4">
    <div class="row mx-5">
      <KeepComponent v-for="keep in state.keeps" :key="keep.id" :keep-prop="keep" />
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
      keeps: computed(() => AppState.keeps)
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
