export class PageResult<T>
{
  count: number = 0;
  pageIndex: number = 0;
  pageSize: number = 0;
  items: T[] = [];
}
