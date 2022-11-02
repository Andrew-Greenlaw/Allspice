import { AppState } from '../AppState'
import { Favorite } from '../models/Favorite.js'
import { Recipe } from '../models/Recipe.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  // async getMyRecipes() {
  //   const res = await api.get('account/recipes')
  //   console.log('My recipes', res.data)
  //   AppState.recipes = res.data.map(r => new Recipe(r))
  // }
  async getFavorites() {
    const res = await api.get('account/favorites')
    console.log('Favorites', res.data)
    AppState.favorites = res.data.map(f => new Favorite(f))
  }
}

export const accountService = new AccountService()
