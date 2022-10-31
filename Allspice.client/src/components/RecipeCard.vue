<template>
  <div class="col-md-4 p-5">
    <div class="recipe-card rounded elevation-5" :style="{ backgroundImage: `url(${recipe.img}` }">
      <div class="text p-3 d-flex justify-content-between flex-column">
        <div class="d-flex justify-content-between">
          <div class="background-tag text-light p-2">
            <h5 class="m-0">{{ recipe.category }}</h5>
          </div>
          <div class="background-tag p-2">
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
import { Recipe } from '../models/Recipe.js';
export default {
  props: {
    recipe: {
      type: Recipe,
      required: true
    }
  },
  setup() {
    return {}
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