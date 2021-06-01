import { reactive } from 'vue'

export const AppState = reactive({
  user: {},
  account: {},
  vaults: [],
  activeVault: {},
  keeps: [],
  activeKeep: {}
})
