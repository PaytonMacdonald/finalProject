import { AppState } from '../AppState'
import { api } from './AxiosService'
class VaultKeepsService {
  async createVaultKeep(data) {
    const res = await api.post('/api/vaultkeeps', data)
    AppState.vaultKeeps.push(res.data)
  }

  async deleteVaultKeep(id) {
    await api.delete(`/api/vaultkeeps/${id}`)
    AppState.vaultKeeps = AppState.vaultKeeps.filter(x => x.id !== id)
  }
}

export const vaultkeepsService = new VaultKeepsService()
