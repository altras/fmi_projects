#include <iostream>
using namespace std;
struct Ls {
	Ls *next;
	int data;
};
struct Stack {
	Ls *start;
};
void push(Stack &st,int d) {
	Ls *ls = new Ls();
	ls->next=st.start;
	ls->data=d;
	st.start=ls;
}
void pop(Stack &st) {
	if(st.start!=NULL) {
		Ls *oldTop= st.start;
		st.start=st.start->next;
		delete oldTop;
	}
}
int top(Stack &st) {
	int result;
	if(st.start!=NULL) {
		result=st.start->data;
	}
	return result;
}

int main() {
	Stack st;
	push(st,20);
	push(st,30);
	push(st,500);
	cout<<top(st)<<" "<<top(st)<<endl;
	pop(st);
	cout<<top(st)<<" "<<top(st)<<endl;
	pop(st);
	cout<<top(st)<<" "<<top(st)<<endl;
}