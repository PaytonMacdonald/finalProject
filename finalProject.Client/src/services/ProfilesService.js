import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class ProfilesService {
  async getProfileById(id) {
    logger.log('connected2')
    const res = await api.get(`api/profiles/${id}`)
    AppState.activeProfile = res.data
  }
}

export const profilesService = new ProfilesService()
