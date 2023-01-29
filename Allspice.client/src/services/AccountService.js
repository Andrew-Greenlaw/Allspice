import { AppState } from '../AppState'
import { Favorite } from '../models/Favorite.js'
import { FavoritedRecipe } from '../models/FavoritedRecipe.js'
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
    AppState.favoritedRecipes = res.data.map(f => new FavoritedRecipe(f))
    console.log(AppState.favoritedRecipes)
  }
  async getMyFavorites() {
    const res = await api.get('account/favorites')
    console.log('favorites', res.data)
    AppState.recipes = res.data.map(f => new FavoritedRecipe(f))
  }
  async getCreatedRecipes() {
    const res = await api.get('account/recipes')
    console.log(res.data)
    AppState.myRecipes = res.data.map(r => new Recipe(r))
  }
  async getMyRecipes() {
    const res = await api.get('account/recipes')
    console.log('myrecipes', res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
  }
}

export const accountService = new AccountService()
