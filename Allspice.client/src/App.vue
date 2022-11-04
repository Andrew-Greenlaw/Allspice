<template>
  <header>
    <Navbar />
  </header>
  <main class="p-5">
    <router-view />
  </main>
  <footer>
    <button type="button" class="btn btn-primary d-flex justify-content-center align-items-center"
      data-bs-toggle="modal" data-bs-target="#exampleModal">
      <i class="mdi mdi-plus fs-1"></i>
    </button>

  </footer>
  <div class="new-modal modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-lg">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          ...
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
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: flex;
  padding: 1rem;
  justify-content: end;
  position: fixed;
  right: 0;
  bottom: 0;
  left: 0;
  z-index: 1030;

  .btn {
    border-radius: 50% !important;
    height: 4rem;
    width: 4rem;
  }
}
</style>
