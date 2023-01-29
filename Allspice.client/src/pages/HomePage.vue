<template>
  <div class="container-fluid">
    <div class="row">
      <RecipeCard v-for="r in recipes" :key="r.id" :recipe="r" />
    </div>
  </div>
  <div class="modal fade" id="recipeDetail" tabindex="-1" aria-labelledby="recipeDetailLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="recipeDetailLabel">Modal title</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <DetailsComponent />
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-primary">Save changes</button>
        </div>
      </div>
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
import { onAuthLoaded } from '@bcwdev/auth0provider-client';

export default {
  setup() {
    async function getRecipes() {
      try {
        await recipesService.getRecipes()
      } catch (error) {
        Pop.error('[GetRecipes]', error)
      }
    }
    onMounted(() => {
      getRecipes()

    })
    return {
      recipes: computed(() => AppState.recipes),
      favoritedRecipes: computed(() => AppState.favoritedRecipes),
      myRecipes: computed(() => AppState.recipes.filter(r => r.creatorId == account.id)),
      account: computed(() => AppState.account),
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
