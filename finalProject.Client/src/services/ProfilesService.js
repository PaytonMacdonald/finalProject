import { AppState } from '../AppState'
import { api } from './AxiosService'
class KeepsService {
  async getAll() {
    const res = await api.get('/api/keeps')
    AppState.keeps = res.data
  }

  async getProfileById(id) {
    const res = await api.get('api/profiles/' + id)
    AppState.activeProfile = res.data
  }
}

export const keepsService = new KeepsService()
