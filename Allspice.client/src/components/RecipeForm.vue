<template>
  <form @submit="handleSubmit()">
    <div class="mb-3">
      <input type="text" class="form-control" id="title" v-model="editable.title" placeholder="Title" required
        aria-label="Name Input">
    </div>
    <div class="mb-3">
      <textarea type="text" class="form-control" id="Instructions" v-model="editable.Instructions"
        placeholder="Instructions" rows="3" required aria-label="Instruction Input"></textarea>
    </div>
    <div class="mb-3">
      <label for="img" class="form-label">Img</label>
      <input type="url" class="form-control" id="img" v-model="editable.img" placeholder="https://Img.com.png" required>
    </div>
    <!-- <div class="mb-3">
              <input type="text" class="form-control" id="type" v-model="editable.type" placeholder="Type"
                aria-label="Type input">
            </div> -->
    <select class="form-select form-select mb-3" v-model="editable.Category" aria-label=".form-select">
      <option selected>Select a Type</option>
      <option value="concert">Concert</option>
      <option value="convention">Convention</option>
      <option value="sport">Sport</option>
      <option value="digital">Digital</option>
    </select>
    <div class="modal-footer">
      <button type="button" class="btn btn-secondary" data-bs-dismiss="modal" aria-label="Close">Close</button>
      <button type="submit" class="btn btn-primary" data-bs-dismiss="modal" aria-label="Create">Create</button>
    </div>

  </form>
</template>


<script>
import { ref } from 'vue'
import { AppState } from '../AppState.js'
import Pop from '../utils/Pop.js'

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async handSubmit() {
        try {

        } catch (error) {
          Pop.error(error, "[Handling Submit]")
        }
      }
    }
  }
}
</script>
<style lang="scss" scoped>

</style>