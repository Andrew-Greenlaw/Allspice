<template>
  <div class="modal-body">
    <form @submit.prevent="handleSubmit()">
      <div class="mb-3">
        <input type="text" class="form-control" id="name" v-model="editable.name" placeholder="Name">
      </div>
      <div class="mb-3">
        <textarea type="text" class="form-control" id="bio" v-model="editable.bio" placeholder="Bio"
          rows="3"></textarea>
      </div>
      <div class="mb-3">
        <label for="picture" class="form-label">Picture</label>
        <input type="url" class="form-control" id="picture" v-model="editable.picture"
          placeholder="https://picture.com.png">
      </div>
      <div class="mb-3">
        <label for="coverImg" class="form-label">CoverImg</label>
        <input type="url" class="form-control" id="coverImg" v-model="editable.coverImg"
          placeholder="https://coverImg.com.png">
      </div>
      <div class="mb-3">
        <label for="class" class="form-label">Class</label>
        <input type="text" class="form-control" id="class" v-model="editable.class" placeholder="fall 2020">
      </div>
      <div class="mb-3">
        <label for="github" class="form-label">Github</label>
        <input type="url" class="form-control" id="github" v-model="editable.github" placeholder="https://github.com">
      </div>
      <div class="mb-3">
        <label for="linkedIn" class="form-label">LinkedIn</label>
        <input type="url" class="form-control" id="linkedIn" v-model="editable.linkedin"
          placeholder="https://linkedIn.com">
      </div>
      <div class="mb-3">
        <label for="resume" class="form-label">Resume</label>
        <input type="url" class="form-control" id="resume" v-model="editable.resume" placeholder="https://resume.com">
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="submit" class="btn btn-primary" data-bs-dismiss="modal">Save changes</button>
      </div>
    </form>
  </div>
</template>


<script>
import { ref, watchEffect } from 'vue';
import { AppState } from '../AppState.js';
import { accountService } from '../services/AccountService.js';
import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const editable = ref({})
    watchEffect(() => {
      editable.value = { ...AppState.account }
    })
    return {
      editable,
      async handleSubmit() {
        try {
          logger.log(editable)
          const formData = editable.value
          await accountService.editAccount(formData)
        } catch (error) {
          Pop.error('[editAccount]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>