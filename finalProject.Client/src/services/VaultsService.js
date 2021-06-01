import { AppState } from '../AppState'
import { api } from './AxiosService'
class VaultsService {
  async create(v) {
    const res = await api.post('/api/vaults', v)
    AppState.vaults.push(res.data)
  }

  async getAll() {
    const res = await api.get('/api/vaults')
    AppState.vaults = res.data
  }

  async getById(v) {
    const res = await api.get('api/vaults/', v)
    AppState.activeVault = res.data
  }

  async update(v) {
    await api.put(`/api/vaults/${v.id}`, v)
  }

  async remove(v) {
    await api.delete(`/api/vaults/${v.id}`)
    AppState.vaults = AppState.vaults.filter(x => x.id !== v.id)
  }
}

export const vaultsService = new VaultsService()
