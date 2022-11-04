<template>
  <div class="col-md-4 p-5">
    <div class="recipe-card rounded elevation-5 selectable" onclick="setActiveRecipe(recipe.id)"
      :style="{ backgroundImage: `url(${recipe.img}` }" data-bs-toggle="modal" data-bs-target="#recipeDetail">
      <div class="text p-3 d-flex justify-content-between flex-column">
        <div class="d-flex justify-content-between">
          <div class="background-tag text-light p-2">
            <h5 class="m-0">{{ recipe.category }}</h5>
          </div>
          <div class="background-tag p-2" v-if="isFavorite">
            <i class="mdi mdi-heart text-danger"></i>
          </div>
          <div class="background-tag p-2" v-else>
            <i class="mdi mdi-heart-outline"></i>
          </div>
        </div>
        <div class="background-text text-light p-2">
          <h4 class="m-0">{{ recipe.title }}</h4>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
export default {
  props: {
    recipe: {
      type: Recipe,
      required: true
    }
  },
  setup(props) {
    return {
      favoritedRecipe: computed(() => AppState.favoritedRecipe),
      isFavorite: computed(() => AppState.favoritedRecipes.find(f => f.id == props.recipe.id)),
      async setActiveRecipe(id) {
        try {
          await recipesService.setActiveRecipe(id)
        } catch (error) {
          Pop.error('[setactiveRecipe]', error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.recipe-card {
  background-size: cover;
  object-fit: cover;
  background-position: center;
  width: 100%;
  padding-top: 100%;
  position: relative;
}

.text {
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}

.background-text {
  background-color: rgba(95, 98, 113, 0.7);
  backdrop-filter: blur(3px);
  border-radius: .2rem;
  outline: .1rem solid rgb(137, 140, 154);
}

.background-tag {
  background-color: rgba(95, 98, 113, 0.7);
  backdrop-filter: blur(3px);
  border-radius: 1rem;
  outline: .1rem solid rgb(137, 140, 154);
}
</style>