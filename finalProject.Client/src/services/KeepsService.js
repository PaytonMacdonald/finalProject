import { AppState } from '../AppState'
import { api } from './AxiosService'
class KeepsService {
  async create(k) {
    const res = await api.post('/api/keeps', k)
    AppState.keeps.push(res.data)
  }

  async getAll() {
    const res = await api.get('/api/keeps')
    AppState.keeps = res.data
  }

  async getById(k) {
    const res = await api.get('api/keeps/', k)
    AppState.activeKeep = res.data
  }

  async update(k) {
    await api.put(`/api/keeps/${k.id}`, k)
  }

  async remove(k) {
    await api.delete(`/api/keeps/${k.id}`)
    AppState.keeps = AppState.keeps.filter(x => x.id !== k.id)
  }
}

export const keepsService = new KeepsService()
