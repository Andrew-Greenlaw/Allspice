<template>
  <div class="container-fluid">
    <div class="row">
      <RecipeCard v-for="r in recipes" :key="r.id" :recipe="r" />
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
      recipes: computed(() => AppState.recipes)
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
