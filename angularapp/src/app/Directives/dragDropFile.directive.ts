import { Directive, EventEmitter, HostListener, Output } from "@angular/core";

export enum DragDropState {
  dragover,
  dragleave,
  drop
}

@Directive({
  selector: "[dragFile]"
})
export class DragDirective {
  @Output() file: EventEmitter<File> = new EventEmitter();
  @Output() state: EventEmitter<DragDropState> = new EventEmitter()

  constructor() { }

  @HostListener("dragover", ["$event"]) public onDragOver(evt: DragEvent) {
    evt.preventDefault();
    evt.stopPropagation();
    this.state.emit(DragDropState.dragover);
  }

  @HostListener("dragleave", ["$event"]) public onDragLeave(evt: DragEvent) {
    evt.preventDefault();
    evt.stopPropagation();
    this.state.emit(DragDropState.dragleave);
  }

  @HostListener('drop', ['$event']) public onDrop(evt: DragEvent) {
    evt.preventDefault();
    evt.stopPropagation();

    let file: File = evt.dataTransfer!.files[0];

    this.file.emit(file);
    this.state.emit(DragDropState.drop);
  }
}
