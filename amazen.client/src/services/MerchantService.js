import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class MerchantService {
  async createMerchant(newMerchant) {
    const res = await api.post('api/merchants', newMerchant)
    logger.log(res.data)
    AppState.activeMerchant = res.data
  }

  async getMerchant(id) {
    const res = await api.get('api/merchants/' + id)
    logger.log('merchant', res.data)
    AppState.activeMerchant = res.data
  }
}

export const merchantService = new MerchantService()
