<template>
  <div class="container-fluid p-5">
    <div class="row allspice rounded elevation-5">
      <div class="col-12">
        <div class="p-3">
          <div class="d-flex justify-content-end pe-4 flex-grow-1">
            <!-- LOGIN COMPONENT HERE -->
            <!-- TODO Search bar -->
            <input type="text">
            <Login />
          </div>
        </div>

      </div>
      <div class="col-12 d-flex justify-content-center">
        <div class="text-center mb-4 text-light">
          <h2>All-Spice</h2>
          <h4>Cherish Your Family</h4>
          <h4>And Their Cooking</h4>
        </div>
      </div>
      <div class="col-12 d-flex justify-content-center">
        <div class="button-component bg-light p-2 rounded elevation-5">
          <button @click="getRecipes()" class="btn pe-3">Home</button>
          <button @click="getMyRecipes()" class="btn mx-4">My Recipes</button>
          <button @click="getFavorites()" class="btn pe-3">Favorites</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { accountService } from '../services/AccountService.js';
import { recipesService } from '../services/RecipesService.js';
import Pop from '../utils/Pop.js';
import Login from './Login.vue'
export default {
  setup() {
    return {
      async getRecipes() {
        try {
          await recipesService.getRecipes()
        } catch (error) {
          Pop.error('GetRecipes', error)
        }
      },
      async getMyRecipes() {
        try {
          await accountService.getMyRecipes()
        } catch (error) {
          Pop.error('[GetMyRecipes]', error)
        }
      },
      async getFavorites() {
        try {
          await favoritesService.getFavorites()
        } catch (error) {
          Pop.error('[GetFavorites]', error)
        }
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
.allspice {
  height: 20rem;
  background-image: url('unsplash_pqJ21tErTgI.png');
  background-position: center;
  background-size: cover;
}

.button-component {
  transform: translateY(3rem);
  display: flex;
  align-items: center;
}

a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
