<template>
  <nav v-if="totalPages > 1">
    <ul class="pagination justify-content-end">
      <li class="page-item" :class="{ disabled: curPage === 1 }">
        <button class="page-link" @click="prevPage()">
          <span>&laquo;</span>
        </button>
      </li>
      <li
        class="page-item"
        :class="{ active: curPage === page }"
        v-for="page in totalPages"
        :key="page"
      >
        <button class="page-link" @click="changePage(page)">
          {{ page }}
        </button>
      </li>
      <li class="page-item" :class="{ disabled: curPage === totalPages }">
        <button class="page-link" @click="nextPage()">
          <span>&raquo;</span>
        </button>
      </li>
    </ul>
  </nav>
</template>

<script>
export default {
  props: {
    curPage: {
      type: Number,
      required: true,
    },
    totalPages: {
      type: Number,
      required: true,
    },
  },
  methods: {
    changePage(page) {
      this.$emit("pageChanged", page);
    },
    nextPage() {
      const page = ++this.curPage;
      this.changePage(page);
    },
    prevPage() {
      const page = --this.curPage;
      this.changePage(page);
    },
  },
};
</script>
