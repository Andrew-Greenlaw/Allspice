<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-4 image">
        <img src="img-fluid" alt="recipe Img">
      </div>
      <div class="col-8 text">

      </div>
    </div>
  </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

export default {
  setup() {
    return {
      recipe: computed((AppState.activeRecipe))
    }
  }
}
</script>


<style lang="scss" scoped>

</style>