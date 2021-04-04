const announcement = new Vue({
    el: "#announcement",
    data: {
        items: [],
        fields: [
            { key: 'announcementId', label: '編號', sortable: true },
            { key: 'context', label: '通知內容', class: '' },
            { key: 'createTime', label: '發布時間', class: '' },
            { key: 'createUser', label: '發布人', class: '' },
            { key: 'editTime', label: '編輯時間', class: '' },
            { key: 'editUser', label: '編輯人', class: '' }
        ],
        isError: false,
        isBusy: true,
        totalRows: 1,
        currentPage: 1,
        perPage: 20,
        pageOptions: [5, 10, 20, { value: 100, text: "100" }],
        sortBy: '',
        sortDesc: false,
        sortDirection: 'asc',
        filter: null,
        filterOn: [],
        infoModal: {
            id: 'info-modal',
            title: '',
            content: ''
        }
    },
    created: function () {
        axios.get("/Api/Announcements/GetAll")
            .then((res) => {
                this.items = res.data.body.announcementList;
                this.mounted();
                this.isBusy = false;
            });
    },
    computed: {
        sortOptions() {
            // Create an options list from our fields
            return this.fields
                .filter(f => f.sortable)
                .map(f => {
                    return { text: f.label, value: f.key }
                })
        }
    },
    mounted() {
        // Set the initial number of items
        this.totalRows = this.items.length
    },
    methods: {
        info(item, index, button) {
            this.infoModal.title = `編號: ${JSON.stringify(item.announcementId, null, 2)}`
            this.infoModal.content = `編號:${JSON.stringify(item.announcementId, null, 2)}\n\n
                                      消息內容:${JSON.stringify(item.context, null, 2)}\n\n
                                      發布時間:${JSON.stringify(item.createTime, null, 2)}\n\n
                                      發布人:${JSON.stringify(item.createUser, null, 2)}\n\n
                                      編輯時間:${JSON.stringify(item.editTime, null, 2)}\n\n
                                      編輯人:${JSON.stringify(item.editUser, null, 2)}\n\n`
            this.$root.$emit('bv::show::modal', this.infoModal.id, button)
        },
        resetInfoModal() {
            this.infoModal.title = ''
            this.infoModal.content = ''
        },
        onFiltered(filteredItems) {
            // Trigger pagination to update the number of buttons/pages due to filtering
            this.totalRows = filteredItems.length
            this.currentPage = 1
        },
        mounted() {
            // Set the initial number of items
            this.totalRows = this.items.length
        }
    },
});