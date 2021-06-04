import { AppState } from '../AppState'
import { api } from './AxiosService'
class KeepsService {
  async createKeep(data) {
    const res = await api.post('/api/keeps', data)
    AppState.keeps.push(res.data)
  }

  async getAllKeeps() {
    const res = await api.get('/api/keeps')
    AppState.keeps = res.data
  }

  async getById(id) {
    const res = await api.get('api/keeps/', id)
    AppState.activeKeep = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.keeps = res.data
  }

  async getKeepsByVaultId(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.vaultKeeps = res.data
  }

  async editKeep(data, id) {
    await api.put('/api/keeps/' + id, data)
    this.getAllKeeps()
  }

  async editKeepCount(data, id) {
    await api.put(`/api/keeps/${id}/count`, data)
    this.getAllKeeps()
  }

  async deleteKeep(id) {
    await api.delete(`/api/keeps/${id}`)
    AppState.keeps = AppState.keeps.filter(x => x.id !== id)
  }
}

export const keepsService = new KeepsService()
