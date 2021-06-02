import { AppState } from '../AppState'
import { api } from './AxiosService'
class VaultsService {
  async createVault(data) {
    const res = await api.post('/api/vaults', data)
    AppState.vaults.push(res.data)
  }

  async getVaultsByProfileId(id) {
    const res = await api.get(`/api/profiles/${id}/vaults`)
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get(`api/vaults/${id}`)
    AppState.activeVault = res.data
  }

  async updateVault(data, id) {
    await api.put(`/api/vaults/${id}`, data)
  }

  async deleteVault(id) {
    await api.delete(`/api/vaults/${id}`)
    AppState.vaults = AppState.vaults.filter(x => x.id !== id)
  }
}

export const vaultsService = new VaultsService()
