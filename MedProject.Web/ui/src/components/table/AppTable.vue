<template>
  <div>
    <table class="table table-hover table-striped">
      <thead>
        <tr>
          <th
            v-for="config in configs"
            :key="config.prop"
            class="position-relative"
            :class="{
              sortable: config.sortable,
              'sort-desc': config.prop === sortBy && sortDir === 'desc',
              'sort-asc': config.prop === sortBy && sortDir === 'asc',
            }"
            :style="{ width: config.width + 'px' }"
            @click="config.sortable && onSort(config.prop)"
          >
            <p>
              {{ config.name || config.prop | capitalize }}
            </p>
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in currentItems" :key="item.id">
          <td
            v-for="config in configs"
            :key="config.name"
            :style="{ width: config.width + 'px' }"
          >
            <p v-if="config.type === 'date'">
              {{ item[config.prop] | formatDate }}
            </p>

            <p v-else>{{ item[config.prop] }}</p>
          </td>
        </tr>
      </tbody>
    </table>

    <app-pagination
      @pageChanged="pageChanged($event)"
      :curPage="page"
      :totalPages="totalPages"
    ></app-pagination>
  </div>
</template>

<script>
import AppPagination from "./AppPagination.vue";
import { orderBy } from "lodash";

export default {
  components: { AppPagination },
  props: {
    configs: {
      typeof: Array,
      required: true,
    },
    data: {
      typeof: Array,
      required: true,
    },
  },
  data: () => ({
    sortBy: "",
    sortDir: "",
    page: 1,
    pageSize: 10,
  }),
  created() {
    this.page = +this.$route.query.page || 1;
  },
  computed: {
    currentItems() {
      if (!this.data?.length) return [];
      const startPos = (this.page - 1) * this.pageSize;
      const data = orderBy(this.data, [this.sortBy], [this.sortDir]);
      return data.slice(startPos, startPos + this.pageSize);
    },
    totalPages() {
      return this.data?.length
        ? Math.ceil(this.data.length / this.pageSize)
        : 0;
    },
  },
  methods: {
    pageChanged(page) {
      // TODO: this page is needed to append to query
      this.page = page;
    },
    onSort(prop) {
      if (this.sortBy === prop) {
        this.sortDir = this.sortDir === "asc" ? "desc" : "asc";
      } else {
        this.sortBy = prop;
        this.sortDir = "asc";
      }
    },
  },
};
</script>

<style lang="scss" scoped>
table,
thead,
tbody {
  display: flex;
  flex-direction: column;
}

tr {
  display: flex;
}

th {
  vertical-align: middle;
}

p {
  margin-bottom: 0px;
}

.sortable {
  cursor: pointer;
  padding-right: 20px;

  p::after,
  p::before {
    border: 3px solid transparent;
    content: "";
    display: block;
    height: 0;
    right: 6px;
    top: 47%;
    position: absolute;
    width: 0;
  }

  p::before {
    border-bottom-color: #585e73;
    margin-top: -7px;
  }

  p::after {
    border-top-color: #585e73;
    margin-top: 3px;
  }
}

.sort-asc {
  color: #b90cc6;

  p:before {
    border-bottom-color: #b90cc6;
    opacity: 0.5;
  }

  p:after {
    border-top-color: #b90cc6;
  }
}

.sort-desc {
  color: #b90cc6;

  p:before {
    border-bottom-color: #b90cc6;
  }
  p:after {
    border-top-color: #b90cc6;
    opacity: 0.5;
  }
}
</style>
