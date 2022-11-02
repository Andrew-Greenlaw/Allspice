<template>
  <div class="container-fluid">
    <div class="row">
      <RecipeCard v-for="r in recipes" :key="r.id" :recipe="r" v-if="recipeFilter == null" />
      <RecipeCard v-for="r in myRecipes" :key="r.id" :recipe="r" v-if="recipeFilter == 'Mine'" />
      <RecipeCard v-for="r in favoritedRecipes" :key="r.id" :recipe="r" />
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { recipesService } from '../services/RecipesService.js';
import RecipeCard from '../components/RecipeCard.vue';
import Pop from '../utils/Pop.js';
import { favoritesService } from '../services/FavoritesService.js';
import { accountService } from '../services/AccountService.js';

export default {
  setup() {
    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        Pop.error('[GetRecipes]', error)
      }
    }
    async function getFavorites() {
      try {
        await accountService.getFavorites()
      } catch (error) {
        Pop.error('[GetFavorites]', error)
      }
    }
    onMounted(() => {
      getRecipes()
    })
    return {
      recipes: computed(() => AppState.recipes),
      favorites: computed(() => AppState.favorites),
      myRecipes: computed(() => AppState.recipes.filter(r => r.creatorId == account.id)),
      favoritedRecipes: computed(() => AppState.recipes.filter(r => {
        for (let f of Appstate.favorites) {
          if (f.recipeId == r.id) {
            return true;
          }
        }
      })),
      account: computed(() => AppState.account),
      recipeFilter: computed(() => AppState.recipeFilter)
    }
  }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
