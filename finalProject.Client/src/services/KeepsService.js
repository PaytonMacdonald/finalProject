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

  async getById(k) {
    const res = await api.get('api/keeps/', k)
    AppState.activeKeep = res.data
  }

  async editKeep(data, id) {
    await api.put('/api/keeps/' + id, data)
    this.getAllKeeps()
  }

  async deleteKeep(id) {
    await api.delete(`/api/keeps/${id}`)
    AppState.keeps = AppState.keeps.filter(x => x.id !== id)
  }
}

export const keepsService = new KeepsService()
