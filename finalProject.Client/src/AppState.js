import { reactive } from 'vue'

export const AppState = reactive({
  user: {},
  account: {},
  activeProfile: {},
  vaults: [],
  activeVault: {},
  keeps: [],
  activeKeep: {},
  vaultKeeps: [],
  myVaults: []
})
