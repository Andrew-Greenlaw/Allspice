import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class FavoritesService {
  async getFavorites() {
    const res = await api.get('api/favorites')
    console.log('Favorites', res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
  }

}
export const favoritesService = new FavoritesService()