<template>
  <div class="container-fluid">
    <div class="row">
      <RecipeCard v-for="r in favorites" :key="r.id" :recipe="r" />
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../AppState.js';

export default {
  setup() {
    return {
      favorites: computed((AppState.favoritedRecipes))
    }
  }
}
</script>


<style lang="scss" scoped>

</style>