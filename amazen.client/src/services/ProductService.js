import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProductService {
  async getAll() {
    const res = await api.get('api/products')
    logger.log('products', res.data)
    AppState.products = res.data
  }

  async getProductsByMerchantId(id) {
    const res = await api.get('api/merchants/' + id + '/products')
    logger.log('merchants products', res.data)
    AppState.products = res.data
  }
}

export const productService = new ProductService()
