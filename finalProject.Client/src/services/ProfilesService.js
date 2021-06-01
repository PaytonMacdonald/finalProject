import { AppState } from '../AppState'
import { api } from './AxiosService'
class KeepsService {
  async getAll() {
    const res = await api.get('/api/keeps')
    AppState.keeps = res.data
  }

  async getById(p) {
    const res = await api.get('api/profiles/', p)
    AppState.activeKeep = res.data
  }
}

export const keepsService = new KeepsService()
