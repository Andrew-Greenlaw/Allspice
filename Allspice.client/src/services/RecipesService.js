import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { api } from "./AxiosService.js"

class RecipesService {

  async getRecipes() {
    const res = await api.get('api/recipes')
    console.log(res.data)
    AppState.recipes = res.data.map(r => new Recipe(r))
  }
  async setActiveRecipe(id) {
    const recipe = AppState.recipes.find({ id })
    console.log(recipe, 'what does this look like?')
    AppState.activeRecipe = recipe
  }
}
export const recipesService = new RecipesService()